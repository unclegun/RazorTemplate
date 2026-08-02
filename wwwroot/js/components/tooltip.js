export function initTooltips() {
  const items = document.querySelectorAll("[data-tooltip]");
  items.forEach((item) => {
    const tooltipId = item.getAttribute("aria-describedby");
    if (!tooltipId) {
      return;
    }

    const tooltip = document.getElementById(tooltipId);
    if (!tooltip) {
      return;
    }

    item.addEventListener("blur", () => {
      tooltip.style.visibility = "hidden";
    });
  });
}