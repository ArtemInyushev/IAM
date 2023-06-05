<template>
	<div class="departments-tree">
		<span>{{ $t("structureCaption") }}</span>
		<department-tree-node
			v-for="department in departments"
			:key="department.id"
			:department="department"
		/>
	</div>
</template>

<script>
import DepartmentTreeNode from './DepartmentTreeNode.vue';

export default {
	name: 'DepartmentsTree',
    components: {
        DepartmentTreeNode
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
	color: var(--grey);
}
</style>