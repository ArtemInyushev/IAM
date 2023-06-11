<template>
	<div class="payroll-card">
		<div class="table-area" style="max-height: calc(50% - 0.5rem)">
			<div>
				<span class="headline ellipsis-overflow">
					{{ $t("payrollCaption") }}
				</span>
			</div>

			<div class="payroll-table-buttons">
				<button type="button" class="btn btn-sm btn-outline-success">
					<i class="bi bi-arrow-repeat"></i>
				</button>

				<div class="staffing-checkbox-area">
					<input class="form-check-input" type="checkbox">
					<label class="form-check-label">{{ $t("includeEmployeesFromchildDepartmentsCaption") }}</label>
				</div>
			</div>

			<div class="table-container">
				<table class="table table-bordered table-hover">
					<thead>
						<tr>
							<th scope="col">
								{{ $t("employeeIdentifierCaption") }}
							</th>
							<th scope="col">
								{{ $t("employeeDisplayNameCaption") }}
							</th>
							<th scope="col">
								{{ $t("accountCaption") }}
							</th>
							<th scope="col">
								{{ $t("employeeProfessionCaption") }}
							</th>
							<th scope="col">
								{{ $t("departmentCaption") }}
							</th>
							<th scope="col">
								{{ $t("staffingCodeCaption") }}
							</th>
						</tr>
					</thead>
					<tbody>
						<tr v-for="employee in employees" :key="employee.id">
							<td>{{ employee.employeeIdentifier }}</td>
							<td>{{ employee.personalDisplayName }}</td>
							<td>{{ employee.accountName }}</td>
							<td>{{ employee.staffingProfessionName }}</td>
							<td>{{ employee.staffingDepartmentFullName }}</td>
							<td>{{ employee.staffingStaffingCode }}</td>
						</tr>
					</tbody>
				</table>
			</div>
		</div>

		<router-view />
	</div>
</template>

<script>
export default {
    name: 'PayrollCard',
	props: {
		departmentId: {
			type: String,
			required: true,
		},
	},
	data() {
		return {
			employees: [],
		};
	},
	async created() {
		await this.loadEmployees();
	},
	methods: {
		async loadEmployees() {
			try{
				const response = await this.axios.get('employees/departmentId', {
					params: {
						departmentId: this.departmentId
					}
				});
				this.employees = response.data;
			}
			catch (err) {
                console.log(err);
            }
		},
	}
}
</script>

<style scoped>
.payroll-card {
	flex: auto;
	display: flex;
	flex-flow: column;
	row-gap: 1rem;
	padding: 1rem;
    overflow: auto;
}

.payroll-table-buttons {
    display: flex;
    flex-flow: row;
    column-gap: 1.5rem;
	align-items: center;
}

.staffing-checkbox-area {
	display: flex;
    flex-flow: row;
    column-gap: 0.5rem;
}

input[type="checkbox"] {
	width: 1.2rem;
	height: 1.2rem;
	border: 1px solid var(--grey-secondary);
	border-radius: calc(var(--border-radius) / 2);
	box-shadow: none;
	margin: 0;
}

input:checked {
	background-color: var(--dark-green);
}

input:focus {
	outline: none;
}
</style>