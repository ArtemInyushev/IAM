<template>
	<div class="departments-tree">
		<div class="logo-container">
			<i style="font-size: 2rem; -webkit-text-stroke: 0.5px; transform: rotate(90deg);" class="bi bi-key"></i>
			<span class="main-caption">IAM</span>
		</div>

		<div class="structure-container">
			<span class="structure-caption ellipsis-overflow">{{ $t("structureCaption") }}</span>
		</div>

		<div>
			<department-tree-node
				v-for="department in departments"
				:key="department.id"
				:department="department"
				:selected-department-id="selectedDepartmentId"
			/>
		</div>
	</div>
</template>

<script>
import DepartmentTreeNode from './DepartmentTreeNode.vue';

export default {
	name: 'DepartmentsTree',
    components: {
        DepartmentTreeNode
    },
	props: {
        selectedDepartmentId: {
            type: Number,
            default: 0,
        },
    },
    data() {
        return {
            departments: [],
        };
    },
	created() {
        this.loadTree();
    },
    methods: {
        async loadTree() {
            try {
                const response = await this.axios.get('departments/tree');
                this.departments = response.data;
            }
            catch (err) {
                console.log(err);
            }
        }
    }
}
</script>

<style scoped>
.departments-tree {
	display: flex;
	flex-flow: column;
	row-gap: 1rem;
	padding: 2rem 0.5rem 0.5rem 0;
}

.logo-container {
	height: fit-content;
	display: flex;
	flex-flow: row;
	column-gap: 0.3rem;
	justify-content: center;
	align-items: center;
	color: var(--light-green);
}

.main-caption {
	font-size: 2rem;
	font-weight: 600;
}

.structure-container {
	height: 3rem;
}

.structure-caption {
	height: 100%;
	display: flex;
	align-items: center;
	padding-left: 0.5rem;
	font-size: 1.5rem;
	color: var(--grey);
}
</style>