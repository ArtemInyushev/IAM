<template>
	<div class="background"></div>
	<div class="iam-search">
		<div class="close-button-area">
			<button class="close-button" @click="onCloseClick">
				<i class="bi bi-x"></i>
			</button>
		</div>

		<div class="search-area">
			<div class="main-caption-area">
				<div>{{ caption }}</div>
			</div>

			<div class="input-group">
				<input
					v-model="inputSearch"
					type="text"
					:placeholder="$t('baseSearchCaption')"
					class="form-control"
				>
				<button class="btn btn-outline-secondary search-button" type="button">
					<i class="bi bi-search"></i>
				</button>
			</div>

			<div class="content-area">
				<div v-for="item in searchedData" :key="item.id" class="content-item">
					<input 
						class="form-check-input" 
						type="checkbox"
					> 
					<span class="name-caption">{{ item.name }}</span>
					<span class="secondary-caption">{{ item.description }}</span>
				</div>
			</div>

			<div class="save-button-area">
				<button type="button" class="btn btn-success">
					{{ $t("saveCaption") }}
				</button>
			</div>
		</div>
	</div>
</template>

<script>
export default {
    name: 'IamSearch',
	props: {
		query: {
			type: String,
			required: true,
		},
		caption: {
			type: String,
			default: ''
		},
	},
	emits: ['close'],
	data() {
		return {
			inputSearch: '',
			searchedData: [],
		};
	},
	async created() {
		await this.loadData();
	},
	methods: {
		async loadData() {
			const params = {
				query: this.inputText,
				type: 1,
			};

			try {
				var response = await this.axios.get(`${this.query}/Search`, { params });
				this.searchedData = response.data;
				console.log(this.searchedData);
			}
			catch (err) {
				console.log(err);
			}
		},
		onCloseClick() {
			this.$emit('close');
		}
	}
}
</script>

<style scoped>
.iam-search {
	position: fixed;
	height: 100%;
	width: 50%;
	top: 0;
	right: 0;
	bottom: 0;
	background-color: white;
	z-index: 10;
}

.iam-search {
	display: flex;
	flex-flow: column;
	row-gap: 4rem;
	padding: 1rem 1rem 2rem;
}

.close-button-area {
	display: flex;
	justify-content: flex-end;
}

.search-area {
	flex: auto;
	display: flex;
	flex-flow: column;
	row-gap: 1rem;
	overflow: auto;
}

.main-caption-area {
	border-bottom: 0.5px solid var(--grey-secondary);
}

.search-button {
	color: white;
	background-color: var(--dark-grey);
}

.content-area {
	flex: auto;
	display: flex;
	flex-flow: column;
	row-gap: 1rem;
	padding: 1rem 1rem 0;
	overflow: auto;
}

.content-item {
	display: flex;
	flex-flow: row;
	column-gap: 1rem;
	align-items: center;
	border-bottom: 0.5px solid var(--grey-secondary);
}

.name-caption {
	flex: 0 1 40%;
	overflow-wrap: anywhere;
}

.secondary-caption {
	flex: 1 1;
	color: var(--dark-grey);
	overflow-wrap: anywhere;
}

.save-button-area {
	display: flex;
	justify-content: center;
}

input[type="checkbox"] {
	width: 1rem;
	height: 1rem;
	border: 1px solid var(--grey-secondary);
	border-radius: calc(var(--border-radius) / 2);
	box-shadow: none;
	margin: 0;
}

input:checked {
	background-color: var(--dark-green);
}
</style>