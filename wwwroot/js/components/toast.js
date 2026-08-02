export function initToasts() {
  const region = document.querySelector("[data-toast-region]");
  if (!region) {
    return;
  }

  const toasts = region.querySelectorAll("[data-toast][data-auto-dismiss]");
  toasts.forEach((toast) => {
    const duration = Number(toast.getAttribute("data-auto-dismiss"));
    if (Number.isFinite(duration) && duration > 0) {
      window.setTimeout(() => {
        toast.remove();
      }, duration);
    }
  });
}