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
    --dark-grey: #37424A;
	--light-blue: #CCDDFF;
    --green: #4CD964;
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

.background {
    position: fixed;
    top: 0;
    left: 0;
    width: 100vw;
    height: 100vh;
    opacity: 0.4;
    background-color: black;
    z-index: 5;
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

.table {
    margin: 0;
}

.close-button {
    padding: 0;
    font-size: 2rem;
    color: var(--dark-green);
    border: none;
    background: none;
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

::-webkit-scrollbar{
    width: 6px;
    height: 6px;
}

::-webkit-scrollbar-track {
    background-color: var(--grey-secondary);
    border-radius: calc(var(--border-radius) / 2);
}

::-webkit-scrollbar-thumb {
    background-color: var(--dark-green);
    border-radius: calc(var(--border-radius) / 2);
}
</style>
