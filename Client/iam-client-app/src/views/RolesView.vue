<template>
	<div class="roles-view">
		<div class="roles-content" style="width: 40%">
			<div class="table-area" style="height: 50%">
				<div>
					<span class="headline ellipsis-overflow">
						{{ $t("departmentsRolesCaption") }}
					</span>
				</div>

				<div class="table-buttons">
					<button type="button" class="btn btn-sm btn-outline-success">
						<i class="bi bi-arrow-repeat"></i>
					</button>

					<button type="button" class="btn btn-sm btn-outline-success" @click="onCreateEntRole">
						<i class="bi bi-plus-lg"></i>
					</button>
				</div>

				<div class="table-container">
					<table class="table table-bordered table-hover">
						<thead>
							<tr>
								<th scope="col">
									{{ $t("roleCodeCaption") }}
								</th>
								<th scope="col">
									{{ $t("descriptionCaption") }}
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

			<div class="table-area" style="height: 50%">
				<div>
					<span class="headline ellipsis-overflow">
						{{ $t("assignedRolesCaption") }}
					</span>
				</div>

				<div class="table-buttons">
					<button type="button" class="btn btn-sm btn-outline-success">
						<i class="bi bi-plus-lg"></i>
					</button>

					<button 
						type="button" 
						class="btn btn-sm btn-outline-success filter-button" 
						@click="withoutFeatureFilter = !withoutFeatureFilter"
					>
						<i class="bi" :class="{'bi-funnel' : !withoutFeatureFilter , 'bi-funnel-fill' : withoutFeatureFilter}"></i>
						<span>{{ $t("withoutFeatureCaption") }}</span>
					</button>
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
		</div>

		<router-view />
	</div>
</template>

<script>
export default {
    name: 'RolesView',
	props: {
        departmentId: {
            type: String,
            default: '',
        },
    },
	data() {
		return {
			withoutFeatureFilter: false,
		};
	},
	watch: {
		departmentId() {
			console.log(this.departmentId);
		}
	},
	created() {
		//console.log(this.departmentId);
	},
	methods: {
		onCreateEntRole() {
			this.$router.push({
				name: 'CreateEntRole',
			});
		},
	}
}
</script>

<style scoped>
.roles-view {
	flex: auto;
	display: flex;
	flex-flow: row;
	column-gap: 1rem;
	padding: 1rem;
	overflow: auto;
}

.roles-content {
	display: flex;
	flex-flow: column;
	row-gap: 1rem;
}

.filter-button {
	display: flex;
	flex-flow: row;
	column-gap: 0.5rem;
}
</style>