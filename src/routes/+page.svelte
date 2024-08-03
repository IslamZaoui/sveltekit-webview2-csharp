<script lang="ts">
	import { invoke } from '$lib/invoke';

	let name = '';
</script>

<div
	class="flex min-h-screen select-none flex-col items-center justify-center bg-gray-100 p-8 text-gray-900 dark:bg-gray-900 dark:text-gray-100"
>
	<h1 class="mb-8 text-4xl font-semibold">what if tauri uses .NET instead of rust?</h1>

	<div class="mb-4 flex space-x-8">
		<a href="https://vitejs.dev" target="_blank">
			<img
				src="/vitejs.svg"
				class="h-32 p-6 transition-shadow duration-500 hover:drop-shadow-[0_0_2em_#747bff] dark:hover:drop-shadow-[0_0_2em_#747bff]"
				alt="Vite Logo"
			/>
		</a>
		<a href="https://dotnet.microsoft.com" target="_blank">
			<img
				src="/dotnet.svg"
				class="h-32 p-6 transition-shadow duration-500 hover:drop-shadow-[0_0_2em_#512bd4] dark:hover:drop-shadow-[0_0_2em_#512bd4]"
				alt=".Net Logo"
			/>
		</a>
		<a href="https://kit.svelte.dev" target="_blank">
			<img
				src="/svelte.svg"
				class="h-32 p-6 transition-shadow duration-500 hover:drop-shadow-[0_0_2em_#ff3e00] dark:hover:drop-shadow-[0_0_2em_#ff3e00]"
				alt="SvelteKit Logo"
			/>
		</a>
	</div>

	<p class="mb-8">Click on the .Net, Vite, and SvelteKit logos to learn more.</p>

	<form class="flex space-x-2">
		<input
			bind:value={name}
			id="greet-input"
			placeholder="Enter a name..."
			class="rounded-lg border bg-white px-4 py-2 text-gray-900 shadow-sm transition-colors duration-200 focus:border-blue-500 focus:ring focus:ring-blue-500 focus:ring-opacity-50 dark:bg-gray-800 dark:text-gray-100 dark:focus:border-blue-400 dark:focus:ring-blue-400"
		/>
		<button
			type="submit"
			on:click={() => invoke('Greet', { name })}
			class="rounded-lg border bg-white px-4 py-2 text-gray-900 shadow-sm transition-colors duration-200 hover:border-blue-500 hover:bg-gray-100 active:border-blue-500 active:bg-gray-200 dark:bg-gray-800 dark:text-gray-100 dark:hover:bg-gray-700 dark:active:bg-gray-600"
		>
			Greet
		</button>
	</form>
</div>
