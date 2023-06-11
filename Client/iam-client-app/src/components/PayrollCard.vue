<template>
	<div class="payroll-card">
		<div class="table-area" style="height: 50%">
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
					<label class="form-check-label">{{ $t("createBaseOnExistingCaption") }}</label>
				</div>
			</div>

			<div class="table-container">
				<table class="table table-bordered table-hover">
					<thead>
						<tr>
							<th scope="col">
								First
							</th>
							<th scope="col">
								Last
							</th>
						</tr>
					</thead>
					<tbody>
						<tr>
							<td>Mark</td>
							<td>Otto</td>
						</tr>
						<tr>
							<td>Jacob</td>
							<td>Thornton</td>
						</tr>
						<tr>
							<td>Larry</td>
							<td>the Bird</td>
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
}
</script>

<style scoped>
.payroll-card {
	flex: auto;
	display: flex;
	flex-flow: column;
	row-gap: 1rem;
	padding: 1rem;
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