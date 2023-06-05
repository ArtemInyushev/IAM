<template>
	<div :style="[backgroundColor, textColor]" class="tree-item">
		<div class="folder-icon">
			<i
				:style="folderIconWidth"
				class="bi" 
				:class="{ 'bi-folder-fill': isSelected, 'bi-folder': !isSelected }"
			>
			</i>
		</div>

		<span style="cursor: pointer;" class="name-caption ellipsis-overflow" @click="onDepartmentClick">{{ departmentName }}</span>

		<div v-if="department.childDepartments.length > 0">
			<i 
				style="cursor: pointer;"
				class="bi" 
				:class="{ 'bi-chevron-up': displayChildren, 'bi-chevron-down': !displayChildren }"
				@click="displayChildren = !displayChildren"
			>
			</i>
		</div>
	</div>

	<div v-show="displayChildren">
		<department-tree-node 
			v-for="child in department.childDepartments"
			:key="child.id"
			:department="child"
			:selected-department-id="selectedDepartmentId"
			:margin="margin + 0.5"
		/>
	</div>
</template>

<script>
export default {
	name: 'DepartmentsTreeNode',
    props: {
        department: {
            type: Object,
            required: true
        },
		selectedDepartmentId: {
            type: Number,
            default: 0,
        },
        margin: {
            type: Number,
            default: 0
        }
    },
    data() {
        return {
			displayChildren: true,
        };
    },
    computed: {
		isSelected() {
			return this.selectedDepartmentId === this.department.id;
		},
        departmentName() {
            return `${this.department.fullName} (${this.department.departmentCode})`;
        },
		backgroundColor() {
			const backgroundColor = this.isSelected ? 'white' : 'inherit';
			return {
				backgroundColor
			};
		},
		textColor() {
			const color = this.isSelected ? 'var(--dark-green)' : 'var(--grey)';
			return {
				color
			};
		},
		folderIconWidth() {
			const fontSize = this.department.parentId ? '1rem' : '1.5rem';
			return {
				fontSize
			};
		},
		currentMargin() {
			return `${this.margin}rem`;
		}
    },
    created() {

    },
	methods: {
		onDepartmentClick() {
			if (this.isSelected) return;

			this.$router.push({
				name: 'Departments',
				params: {
					departmentId: this.department.id
				}
			});
		}
	}
}
</script>

<style scoped>
.tree-item {
	height: 2rem;
	display: flex;
	flex-flow: row;
	column-gap: 0.5rem;
	align-items: center;
	margin-left: v-bind(currentMargin);
	padding-left: 0.5rem;
	border-radius: calc(var(--border-radius) * 2);
}

.name-caption {
	height: 100%;
	display: flex;
	align-items: center;
}
</style>