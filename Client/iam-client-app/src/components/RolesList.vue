<template>
	<div class="roles-list">
		<div v-for="roleType in roleTypes" :key="roleType.id">
			<div class="roles-header">
				<div class="role-main border-bottom">
					<div class="role-type">
						<b class="name-caption">{{ roleType.name }}</b>
						<span v-show="allRoles[roleType.id]?.length > 0" class="type-count">
							{{ allRoles[roleType.id]?.length }}
						</span>
					</div>
					<button 
						v-show="allRoles[roleType.id]?.length > 0" 
						class="arrow-button"
						@click="showRoles[roleType.id] = !showRoles[roleType.id]"
					>
						<i 
							class="bi" 
							:class="{'bi-chevron-up': showRoles[roleType.id], 'bi-chevron-down': !showRoles[roleType.id]}"
						>
						</i>
					</button>
				</div>
				<button class="modify-button">
					<i class="bi bi-pencil"></i>
				</button>
			</div>

			<div v-show="showRoles[roleType.id]">
				<div v-for="role in allRoles[roleType.id]" :key="role.id" class="role-info border-bottom">
					<span class="role-name name-caption">{{ role.name }}</span>
					<span class="role-description secondary-caption">{{ role.description }}</span>
					<button class="cancel-button">
						<i class="bi bi-x"></i>
					</button>
				</div>
			</div>
		</div>
	</div>
</template>

<script>
export default {
    name: 'RolesList',
	props: {
		roleTypes: {
			type: Array,
			required: true,
		},
		roles: {
			type: Array,
			default() {
				return [];
			},
		},
	},
	data() {
		return {
			allRoles: {},
			showRoles: {},
		};
	},
	created() {
		this.initialize();
	},
	methods: {
		initialize() {
			for (const roleType of this.roleTypes) {
				const roles = this.roles.filter(r => r.type === roleType.id) || [];
				this.allRoles[roleType.id] = roles;
				this.showRoles[roleType.id] = false;
			}
		}
	}
}
</script>

<style scoped>
.roles-list {
	display: flex;
	flex-flow: column;
	row-gap: 1rem;
}

.roles-header {
	height: 1.5rem;
	display: flex;
	flex-flow: row;
}

.role-main {
	flex: 1 1;
	display: flex;
	justify-content: space-between;
}

.border-bottom {
	border-bottom: 0.5px solid var(--grey-secondary);
}

.role-type {
	display: flex;
	flex-flow: row;
	align-items: center;
	column-gap: 0.5rem;
}

.name-caption {
	font-size: 15px;
	line-height: 22px;
}

.secondary-caption {
	font-weight: 400;
	font-size: 11px;
	line-height: 16px;
	overflow-wrap: anywhere;
}

.type-count {
	display: flex;
	justify-content: center;
	align-items: center;
	padding: 0 0.75rem;
	background-color: var(--dark-green);
	border-radius: calc(var(--border-radius) * 2);
	color: white;
	font-weight: 400;
	font-size: 11px;
	line-height: 16px;
}

.arrow-button {
	background: none;
	border: none;
	color: var(--dark-green);
}

.modify-button {
	height: 100%;
	width: 1.5rem;
	display: flex;
	justify-content: center;
	align-items: center;
	background: none;
	color: var(--dark-green);
	border: 1px solid var(--grey-secondary);
	border-radius: var(--border-radius);
}

.cancel-button {
	height: 100%;
	width: 1.5rem;
	font-size: 1.2rem;
	color: var(--grey);
	background: none;
	border: none;
}

.role-info {
	margin: 1rem 1.5rem 0;
	display: flex;
	flex-flow: row;
	column-gap: 1rem;
	align-items: center;
}

.role-name {
	flex: 0 1 40%;
}

.role-description {
	flex: 1 1;
}
</style>