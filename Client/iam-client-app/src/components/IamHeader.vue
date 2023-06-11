<template>
	<div class="iam-header">
		<ul class="nav nav-bars">
			<li class="nav-item">
				<router-link :to="{name: 'Roles'}" class="nav-link iam-nav-link">
					{{ $t("rolesCaption") }}
				</router-link>
			</li>
			<li class="nav-item">
				<router-link :to="{name: 'Staffing'}" class="nav-link iam-nav-link">
					{{ $t("staffingsCaption") }}
				</router-link>
			</li>
			<li class="nav-item">
				<router-link :to="{name: 'Payroll'}" class="nav-link iam-nav-link">
					{{ $t("payrollCaption") }}
				</router-link>
			</li>
		</ul>

		<div style="padding-bottom: 0.5rem;">
			<button type="button" class="btn btn-outline-success personal-info-button">
				<i class="bi bi-person"></i>
			</button>
		</div>
	</div>
</template>

<script>
export default {
    name: 'IamHeader',
}
</script>

<style scoped>
.iam-header {
	display: flex;
	justify-content: space-between;
	align-items: flex-end;
	padding: 0.5rem 1rem 0;
	background-color: #F3F6FA;
}

.iam-nav-link, .iam-nav-link:focus, .iam-nav-link:hover {
	background-color: #FAFCFE;
	border: 1px solid var(--grey-secondary);
	border-radius: var(--border-radius);
	color: var(--grey);
}

.iam-nav-link-active, .iam-nav-link-active:focus, .iam-nav-link-active:hover {
	background-color: white;
	border-bottom-color: white;
	color: var(--light-green);
}

.personal-info-button, .personal-info-button:focus {
	background-color: white;
	border-color: var(--grey-secondary);
	color: var(--grey);
}
</style>