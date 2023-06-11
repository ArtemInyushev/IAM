<template>
	<div class="table-area" style="height: 50%">
		<ul class="nav nav-bars">
			<li class="nav-item">
				<router-link :to="{name: 'AllEntRoles'}" class="nav-link iam-nav-link">
					{{ $t("entRolesCaption") }}
				</router-link>
			</li>
			<li class="nav-item">
				<router-link :to="{name: 'StaffingEntRoles'}" class="nav-link iam-nav-link">
					{{ $t("entRolesAccessCaption") }}
				</router-link>
			</li>
			<li class="nav-item">
				<router-link :to="{name: 'EntRolesNoBase'}" class="nav-link iam-nav-link">
					{{ $t("entRolesNoBaseAccessCaption") }}
				</router-link>
			</li>
			<li class="nav-item">
				<router-link :to="{name: 'AllRoles'}" class="nav-link iam-nav-link">
					{{ $t("allAccessCaption") }}
				</router-link>
			</li>
		</ul>

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
</template>

<script>
export default {
    name: 'PayrollRolesCard',
}
</script>

<style scoped>
.iam-nav-link, .iam-nav-link:focus, .iam-nav-link:hover {
	background-color: #FAFCFE;
	border: 1px solid var(--grey-secondary);
	border-radius: var(--border-radius);
	color: var(--grey);
}

.iam-nav-link-active, .iam-nav-link-active:focus, .iam-nav-link-active:hover {
	background-color: white;
	color: var(--light-green);
}
</style>