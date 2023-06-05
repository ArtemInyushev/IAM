<template>
	<router-view />
</template>

<script>
export default {
    name: 'App',
}
</script>

<style>
:root {
	--grey: #818A8F;
}

html, body {
	height: 100%;
}

body {
	margin: 0;
	overflow: hidden;
}

div#app {
	height: 100%;
	width: 100%;
	font-family: 'Open Sans', sans-serif;
	font-weight: 500;
	font-size: 14px;
	line-height: 18px;
}
</style>
