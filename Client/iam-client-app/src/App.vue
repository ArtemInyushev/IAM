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
	--border-radius: 4px;
	--grey: #818A8F;
	--light-blue: #CCDDFF;
	--light-green: #90EE90;
	--dark-green: #006400;
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

.ellipsis-overflow {
	overflow: hidden;
	text-overflow: ellipsis;
	white-space: nowrap;
}
</style>
