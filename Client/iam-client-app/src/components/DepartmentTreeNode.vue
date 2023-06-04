<template>
	<div>
		<span>{{ departmentName }}</span>

		<department-tree-node 
			v-for="child in department.childDepartments"
			:key="child.id"
			:department="child"
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
        margin: {
            type: Number,
            default: 0
        }
    },
    data() {
        return {

        };
    },
    computed: {
        departmentName() {
            return `${this.department.fullName} (${this.department.departmentCode})`;
        },
    },
    created() {
        console.log(this.department, this.department.childDepartments);
    }
}
</script>