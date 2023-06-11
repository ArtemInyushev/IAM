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
    --grey-secondary: #D0D0D0;
	--light-blue: #CCDDFF;
	--light-green: #90EE90;
	--dark-green: #006400;
    --red: #ED1C24;
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

.table-area {
    width: 100%;
    display: flex;
    flex-flow: column;
    row-gap: 0.5rem;
    padding: 1rem;
    border-radius: var(--border-radius);
    box-shadow: 0 2px 6px rgba(0, 0, 0, 0.4);
}

.table-buttons {
	display: flex;
	flex-flow: row;
	column-gap: 0.5rem;
}

.table-container {
    overflow: auto;
}

table{
    border: 2px solid var(--grey-secondary);
}

.headline {
    font-size: 20px;
    font-weight: 700;
    line-height: 24px;
    letter-spacing: 0.15px;
}

.ellipsis-overflow {
	overflow: hidden;
	text-overflow: ellipsis;
	white-space: nowrap;
}
</style>
