export function initDialogs() {
  const dialogs = document.querySelectorAll("dialog[data-ui-dialog]");

  dialogs.forEach((dialog) => {
    const openers = document.querySelectorAll(`[data-dialog-open=\"${dialog.id}\"]`);
    const closers = dialog.querySelectorAll("[data-dialog-close]");

    openers.forEach((trigger) => {
      trigger.addEventListener("click", () => {
        if (typeof dialog.showModal === "function") {
          dialog.showModal();
        }
      });
    });

    closers.forEach((button) => {
      button.addEventListener("click", () => dialog.close());
    });

    dialog.addEventListener("click", (event) => {
      const rect = dialog.getBoundingClientRect();
      const inside = rect.top <= event.clientY && event.clientY <= rect.bottom && rect.left <= event.clientX && event.clientX <= rect.right;
      if (!inside) {
        dialog.close();
      }
    });
  });
}