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
						<th v-for="column in columns" :key="column" scope="col">
							{{ column }}
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
    data() {
        return {
            allColumns: {
                entRoles: [
                    this.$t("roleCodeCaption"),
                    this.$t("roleTypeCaption"),
                    this.$t("descriptionCaption"),
                    this.$t("inheritChildCaption"),
                ],
                entRolesRoles: [
                    this.$t("roleNameCaption"),
                    this.$t("descriptionCaption"),
                    this.$t("roleTypeCaption"),
                    this.$t("entRoleCaption"),
                ],
                allRoles: [
                    this.$t("roleNameCaption"),
                    this.$t("descriptionCaption"),
                    this.$t("typeCaption"),
                    this.$t("statusCaption"),
                ],
            },
        };
    },
    computed: {
        columns() {
            switch (this.$route.name){
                case 'AllEntRoles':
                    return this.allColumns.entRoles;
                case 'AllRoles':
                    return this.allColumns.allRoles;
                default:
                    return this.allColumns.entRolesRoles;
            }
        }
    }
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