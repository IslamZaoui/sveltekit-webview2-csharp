// See https://kit.svelte.dev/docs/types#app
// for information about these interfaces
declare global {
	namespace App {
		// interface Error {}
		// interface Locals {}
		// interface PageData {}
		// interface PageState {}
		// interface Platform {}
	}
	interface Window {
		chrome: {
			webview: {
				hostObjects: {
					myMethods: MyMethods;
				};
			};
		};
	}
	interface MyMethods {
		Greet(name: string): void;
	}
}

export { };
