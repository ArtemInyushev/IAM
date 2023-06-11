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
</template>

<script>
export default {
    name: 'StaffingCard',
}
</script>

<style scoped>
.staffing-card {
	flex: auto;
	padding: 1rem;
}
</style>