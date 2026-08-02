import { initDialogs } from "./components/dialog.js";
import { initNavigation } from "./components/navigation.js";
import { initTabs } from "./components/tabs.js";
import { initToasts } from "./components/toast.js";
import { initTooltips } from "./components/tooltip.js";

document.addEventListener("DOMContentLoaded", () => {
	initNavigation();
	initDialogs();
	initTabs();
	initToasts();
	initTooltips();

	document.querySelectorAll("[data-copy-code]").forEach((button) => {
		button.addEventListener("click", async () => {
			const target = button.getAttribute("data-copy-code");
			if (!target) return;
			const code = document.querySelector(target);
			if (!code) return;
			try {
				await navigator.clipboard.writeText(code.textContent ?? "");
				button.textContent = "Copied";
				window.setTimeout(() => { button.textContent = "Copy"; }, 1200);
			} catch {
				button.textContent = "Copy failed";
			}
		});
	});
});
