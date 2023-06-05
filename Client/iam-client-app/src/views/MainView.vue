<template>
	<div class="main-component">
		<div :style="componentWidth" class="left-panel">
			<div v-show="!treeHidden" class="tree-container">
				<departments-tree :selected-department-id="departmentIdNumber" />
			</div>

			<div class="toggle-button-container">
				<i 
					style="font-size: 2rem;"
					class="bi" 
					:class="{ 'bi-arrow-right-circle': treeHidden, 'bi-arrow-left-circle': !treeHidden }" 
					@click="treeHidden = !treeHidden"
				>
				</i>
			</div>
		</div>
		<div class="right-panel"></div>
	</div>
</template>

<script>
import DepartmentsTree from '../components/DepartmentsTree.vue';

export default {
	name: 'MainView',
	components: {
		DepartmentsTree,
	},
    props: {
        departmentId: {
            type: String,
            default: '',
        },
    },
	data() {
		return {
			treeHidden: false,
		};
	},
	computed: {
		componentWidth() {
			const width = this.treeHidden ? 'auto' : '30%';
			return {
				width: width
			};
		},
        departmentIdNumber() {
            const id = parseInt(this.departmentId, 10);
            if (Number.isNaN(id)) {
                return 0;
            }
            return id;
        }
	}
}
</script>

<style scoped>
.main-component {
	height: 100%;
	width: 100%;
    display: flex;
    flex-flow: row;
}

.left-panel {
	display: flex;
	flex-flow: row;
	background-color: #212121;
}

.right-panel {
	flex: auto;
}

.tree-container {
	flex: auto;
    overflow: hidden;
}

.toggle-button-container{
    flex: 0;
	display: flex;
	align-items: center;
	justify-content: center;
	padding: 0.5rem;
	color: var(--light-blue);
}
</style>
