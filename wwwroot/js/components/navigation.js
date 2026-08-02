export function initNavigation() {
  const navs = document.querySelectorAll("[data-nav]");

  navs.forEach((nav) => {
    const toggle = nav.querySelector("[data-nav-toggle]");
    const menu = nav.querySelector("[data-nav-menu]");
    if (!toggle || !menu) {
      return;
    }

    toggle.addEventListener("click", () => {
      const isOpen = menu.classList.toggle("is-open");
      toggle.setAttribute("aria-expanded", String(isOpen));
    });

    document.addEventListener("click", (event) => {
      if (!nav.contains(event.target)) {
        menu.classList.remove("is-open");
        toggle.setAttribute("aria-expanded", "false");
      }
    });

    nav.addEventListener("keydown", (event) => {
      if (event.key === "Escape") {
        menu.classList.remove("is-open");
        toggle.setAttribute("aria-expanded", "false");
        toggle.focus();
      }
    });
  });
}