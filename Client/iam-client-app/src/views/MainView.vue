<template>
	<div class="main-component">
		<div :style="componentWidth" class="left-panel">
			<div v-show="!treeHidden" class="tree-container">
				<departments-tree />
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
}

.toggle-button-container{
	display: flex;
	align-items: center;
	justify-content: center;
	padding: 0.5rem;
	color: var(--grey);
}
</style>
