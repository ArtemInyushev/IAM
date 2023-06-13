<template>
	<div class="table-area" style="max-height: calc(50% - 0.5rem)">
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
							{{ $t("roleNameCaption") }}
						</th>
						<th scope="col">
							{{ $t("descriptionCaption") }}
						</th>
						<th scope="col">
							{{ $t("typeCaption") }}
						</th>
						<th scope="col">
							{{ $t("statusCaption") }}
						</th>
					</tr>
				</thead>
				<tbody>
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