<template>
	<div class="staffing-card">
		<div class="table-area">
			<div>
				<span class="headline ellipsis-overflow">
					{{ $t("staffingsCaption") }}
				</span>
			</div>

			<div class="table-buttons">
				<button type="button" class="btn btn-sm btn-outline-success">
					<i class="bi bi-arrow-repeat"></i>
				</button>

				<button type="button" class="btn btn-sm btn-outline-success">
					<i class="bi bi-plus-lg"></i>
				</button>
			</div>

			<div class="table-container">
				<table class="table table-bordered table-hover">
					<thead>
						<tr>
							<th scope="col">
								{{ $t("staffingCodeCaption") }}
							</th>
							<th scope="col">
								{{ $t("professionNameCaption") }}
							</th>
							<th scope="col">
								{{ $t("roleCodeCaption") }}
							</th>
						</tr>
					</thead>
					<tbody>
						<tr v-for="staffing in staffings" :key="staffing.id">
							<td>{{ staffing.staffingCode }}</td>
							<td>{{ staffing.professionName }}</td>
							<td>{{ staffing.EntRoleCode }}</td>
						</tr>
					</tbody>
				</table>
			</div>
		</div>
	</div>
</template>

<script>
export default {
    name: 'StaffingCard',
	props: {
		departmentId: {
			type: String,
			required: true,
		},
	},
	data() {
		return {
			staffings: [],
		};
	},
	async created() {
		await this.loadStaffings();
	},
	methods: {
		async loadStaffings() {
			try{
				const response = await this.axios.get('staffings/departmentId', {
					params: {
						departmentId: this.departmentId
					}
				});
				this.staffings = response.data;
			}
			catch (err) {
                console.log(err);
            }
		},
	}
}
</script>

<style scoped>
.staffing-card {
	flex: auto;
	padding: 1rem;
    overflow: auto;
}
</style>