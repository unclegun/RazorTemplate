function activateTab(tabList, nextTab) {
  const tabs = tabList.querySelectorAll('[role="tab"]');
  tabs.forEach((tab) => {
    const active = tab === nextTab;
    tab.setAttribute("aria-selected", String(active));
    tab.tabIndex = active ? 0 : -1;
    const panelId = tab.getAttribute("aria-controls");
    const panel = panelId ? document.getElementById(panelId) : null;
    if (panel) {
      panel.hidden = !active;
    }
  });
}

export function initTabs() {
  const lists = document.querySelectorAll('[role="tablist"][data-ui-tabs]');

  lists.forEach((tabList) => {
    const tabs = Array.from(tabList.querySelectorAll('[role="tab"]'));
    tabs.forEach((tab, index) => {
      tab.addEventListener("click", () => activateTab(tabList, tab));
      tab.addEventListener("keydown", (event) => {
        const currentIndex = tabs.indexOf(tab);
        let nextIndex = currentIndex;
        if (event.key === "ArrowRight") nextIndex = (currentIndex + 1) % tabs.length;
        if (event.key === "ArrowLeft") nextIndex = (currentIndex - 1 + tabs.length) % tabs.length;
        if (event.key === "Home") nextIndex = 0;
        if (event.key === "End") nextIndex = tabs.length - 1;
        if (nextIndex !== currentIndex) {
          event.preventDefault();
          tabs[nextIndex].focus();
          activateTab(tabList, tabs[nextIndex]);
        }
      });

      if (index === 0 && !tabs.some((x) => x.getAttribute("aria-selected") === "true")) {
        tab.setAttribute("aria-selected", "true");
      }
    });
  });
}