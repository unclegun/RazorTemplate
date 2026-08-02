import { initDialogs } from "../../../wwwroot/js/components/dialog.js";
import { initNavigation } from "../../../wwwroot/js/components/navigation.js";
import { initTabs } from "../../../wwwroot/js/components/tabs.js";
import { initToasts } from "../../../wwwroot/js/components/toast.js";
import { initTooltips } from "../../../wwwroot/js/components/tooltip.js";

document.addEventListener("DOMContentLoaded", () => {
  initNavigation();
  initDialogs();
  initTabs();
  initToasts();
  initTooltips();
});
