<template>
	<label class="switch">
		<input v-model="isChecked" type="checkbox">
		<span class="slider round"></span>
	</label>
</template>

<script>
export default {
    name: 'IamSwitcher',
	props: {
		checked: {
			type: Boolean,
			required: true,
		}
	},
	emits: ['switch'],
	data() {
		return {
			isChecked: false,
		};
	},
	watch: {
		isChecked() {
			this.$emit('switch', this.isChecked);
		}
	},
	created() {
		this.isChecked = this.checked;
	}
}
</script>

<style scoped>
.switch {
	position: relative;
	display: inline-block;
	width: 28px;
	height: 16px;
}

.switch input {
	opacity: 0;
	width: 0;
	height: 0;
}

.slider {
	position: absolute;
	cursor: pointer;
	top: 0;
	right: 0;
	bottom: 0;
	left: 0;
	background-color: var(--grey-secondary);
	box-shadow: 0 2px 18px rgba(0, 0, 0, 0.1);
	border-radius: var(--border-radius);
	transition: 0.4s;
}

.slider::before {
	position: absolute;
	content: "";
	height: 16px;
	width: 16px;
	background-color: white;
	box-shadow: 0 2px 18px rgba(0, 0, 0, 0.1);
	border-radius: var(--border-radius);
	transition: 0.4s;
}

input:checked + .slider {
	background-color: var(--green);
}

input:focus + .slider {
	box-shadow: 0 0 1px var(--green);
}

input:checked + .slider::before {
	transform: translateX(14px);
}

.slider.round {
	border-radius: 5px;
}
</style>