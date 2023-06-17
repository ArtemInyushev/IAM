<template>
	<div class="ent-role-card">
		<div class="ent-role-card-main">
			<div class="header-container">
				<div class="header-main-caption-area">
					<div class="header-part">
						<span class="ellipsis-overflow headline">
							{{ $t("roleCardCaption") }}
						</span>

						<div class="status-panel">
							{{ entRoleStatusText }}
						</div>
					</div>

					<div class="switcher-panel">
						<iam-switcher :checked="entRoleNewStatus" @switch="value => entRoleNewStatus = value" />
						<span>{{ entRoleNewStatusText }}</span>
					</div>
				</div>
				
				<button type="button" class="btn btn-sm btn-success save-button">
					<i class="bi bi-save"></i>
					<span>{{ $t("saveCaption") }}</span>
				</button>
			</div>

			<div class="form-row">
				<div class="form-item form-select-item-container">
					<span>{{ $t("departmentCaption") }}</span>
					<div class="form-select-item form-item-disabled">
						<div class="form-select-text-container">
							<span class="ellipsis-overflow"></span>
						</div>
						
						<i class="bi bi-list-ul list-icon"></i>
					</div>
				</div>

				<div class="form-item form-select-item-container">
					<span>{{ $t("staffingCaption") }}</span>
					<div class="form-select-item form-item-disabled">
						<div class="form-select-text-container">
							<span class="ellipsis-overflow"></span>
						</div>
						
						<i class="bi bi-list-ul list-icon"></i>
					</div>
				</div>
			</div>

			<div class="form-row">
				<div class="form-item form-select-item-container">
					<span>{{ $t("roleTypeCaption") }}</span>
					<div class="form-select-item form-item-disabled">
						<div class="form-select-text-container">
							<span class="ellipsis-overflow"></span>
						</div>
						
						<i class="bi bi-list-ul list-icon"></i>
					</div>
				</div>

				<div class="form-item form-select-item-container">
					<span>{{ $t("roleCodeCaption") }}</span>
					<div class="form-select-item form-item-disabled">
						<div class="form-select-text-container">
							<span class="ellipsis-overflow"></span>
						</div>
						
						<i class="bi bi-list-ul list-icon"></i>
					</div>
				</div>
			</div>

			<div class="form-row">
				<input class="form-check-input" type="checkbox">
				<label class="form-check-label">{{ $t("inheritChildCaption") }}</label>
			</div>

			<div>
				<span>{{ $t("descriptionCaption") }}</span>
				<input class="description-input" type="text">
			</div>

			<div class="form-row">
				<div class="form-item form-select-item-container">
					<span>{{ $t("initiatorCaption") }}</span>
					<div class="form-select-item form-item-disabled">
						<div class="form-select-text-container">
							<span class="ellipsis-overflow"></span>
						</div>
						
						<i class="bi bi-list-ul list-icon"></i>
					</div>
				</div>
			</div>

			<template v-if="roleTypes.length > 0">
				<roles-list style="padding-top: 1rem" :role-types="roleTypes" :roles="roles" />
			</template>
		</div>

		<div class="delete-button-container">
			<button class="btn btn-lg btn-dark">
				{{ $t("deleteCaption") }}
			</button>
		</div>
	</div>
</template>

<script>
import IamSwitcher from './IamSwitcher.vue';
import RolesList from './RolesList.vue';

export default {
    name: 'EntRoleCard',
	components: {
		IamSwitcher,
		RolesList,
	},
	data() {
		return {
			roleTypes: [],
			roles: [],

			entRoleActive: true,
			entRoleNewStatus: true,
		};
	},
	computed: {
		entRoleStatusText() {
			if (this.entRoleActive) {
				return this.$t("activeCaption");
			}
			else {
				return this.$t("deactivatedCaption");
			}
		},
		entRoleNewStatusText() {
			if (this.entRoleNewStatus) {
				return this.$t("deactivateCaption");
			}
			else {
				return this.$t("activateCaption");
			}
		},
		entRoleStatusColor() {
			if (this.entRoleActive) {
				return 'var(--green)';
			}
			else {
				return 'var(--red)';
			}
		},
	},
	async created() {
		const roleTypesResponse = await this.axios.get("roles/types");
		this.roleTypes = roleTypesResponse.data;
	},
}
</script>

<style scoped>
.ent-role-card {
    flex: auto;
	display: flex;
    flex-flow: column;
    row-gap: 1rem;
	justify-content: space-between;
    border-radius: var(--border-radius);
    box-shadow: 0 2px 6px rgba(0, 0, 0, 0.4);
    overflow: auto;
}

.ent-role-card-main {
	display: flex;
    flex-flow: column;
    row-gap: 1rem;
	padding: 1rem;
}

.header-container {
	display: flex;
	flex-flow: row;
	justify-content: space-between;
	align-items: flex-start;
}

.header-main-caption-area {
	display: flex;
	flex-flow: column;
	row-gap: 0.5rem;
}

.header-part {
	display: flex;
	flex-flow: row;
	column-gap: 0.5rem;
}

.status-panel {
	height: 1.5rem;
	display: flex;
	align-items: center;
	padding: 0 1.5rem;
	border-radius: calc(var(--border-radius) / 2);
	background-color: v-bind(entRoleStatusColor);
}

.switcher-panel {
	width: fit-content;
	display: flex;
	flex-flow: row;
	column-gap: 1rem;
	align-items: center;
	padding: 0.2rem 1.5rem;
	border: 1px solid var(--grey-secondary);
	border-radius: var(--border-radius);
}

.save-button {
	display: flex;
	flex-flow: row;
	column-gap: 0.5rem;
}

.form-row {
	display: flex;
	flex-flow: row;
	column-gap: 1rem;
}

.form-item {
	display: flex;
	flex-flow: column;
}

.form-select-item-container {
	width: 50%;
}

.form-select-item {
	width: 100%;
	height: 2rem;
	display: flex;
	flex-flow: row;
	column-gap: 0.5rem;
	align-items: center;
	padding: 0 0.5rem;
	border: 1px solid var(--grey-secondary);
	border-radius: var(--border-radius);
}

.form-item-disabled {
	pointer-events: none;
	background-color: #F3F3F3;
	color: var(--grey);
}

.form-select-text-container {
	width: 100%;
}

.list-icon {
	cursor: pointer;
}

.description-input {
	width: 100%;
	height: 2rem;
	padding: 0 0.5rem;
	border: 1px solid var(--grey-secondary);
	border-radius: var(--border-radius);
}

.form-check-label {
	display: flex;
	align-items: center;
}

.form-row-checkbox-container {
    width: 50%;
    display: flex;
    flex-flow: row;
    column-gap: 1rem;
    align-items: center;
}

.delete-button-container {
	display: flex;
	justify-content: center;
	padding: 1rem 0;
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