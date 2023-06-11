<template>
	<div class="create-ent-role-card">
		<div class="header-container">
			<span class="ellipsis-overflow headline">
				{{ $t("roleCreationCaption") }}
			</span>

			<button type="button" class="btn btn-danger">
				<i class="bi bi-save"></i>
			</button>
		</div>

		<div class="form-row">
			<div class="form-item form-select-item-container">
				<span>{{ $t("departmentCaption") }}</span>
				<div class="form-select-item">
					<div class="form-select-text-container">
						<span class="ellipsis-overflow"></span>
					</div>
					
					<i class="bi bi-list-ul list-icon"></i>
				</div>
			</div>

			<div class="form-select-item-container">
				<span>{{ $t("staffingCaption") }}</span>
				<div class="form-select-item">
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
			<div class="form-row-checkbox-container">
				<input class="form-check-input" type="checkbox">
				<label class="form-check-label">{{ $t("createBaseOnExistingCaption") }}</label>
			</div>

			<div class="form-item form-select-item-container">
				<span>{{ $t("chooseRoleCaption") }}</span>
				<div class="form-select-item">
					<div class="form-select-text-container">
						<span class="ellipsis-overflow"></span>
					</div>
					
					<i class="bi bi-list-ul list-icon"></i>
				</div>
			</div>
		</div>

		<template v-if="roleTypes.length > 0">
			<roles-list :role-types="roleTypes" />
		</template>
	</div>
</template>

<script>
import RolesList from './RolesList.vue';

export default {
    name: 'CreateEntRoleCard',
	components: {
		RolesList,
	},
	data() {
		return {
			roleTypes: [],
		};
	},
	async created() {
		const roleTypesResponse = await this.axios.get("roles/types");
		this.roleTypes = roleTypesResponse.data;
	},
}
</script>

<style scoped>
.create-ent-role-card {
    flex: auto;
    display: flex;
    flex-flow: column;
    row-gap: 1rem;
	padding: 1rem;
    border-radius: var(--border-radius);
    box-shadow: 0 2px 6px rgba(0, 0, 0, 0.4);
    overflow: auto;
}

.header-container {
	display: flex;
	flex-flow: row;
	justify-content: space-between;
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

.form-select-text-container {
	width: 100%;
	height: 100%;
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