(function () {
  function initCountdown(eventDateIso) {
    var container = document.getElementById("countdown");
    if (!container || !eventDateIso) return;

    var target = new Date(eventDateIso).getTime();

    function update() {
      var now = Date.now();
      var diff = Math.max(0, target - now);

      var days = Math.floor(diff / (1000 * 60 * 60 * 24));
      var hours = Math.floor((diff % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
      var minutes = Math.floor((diff % (1000 * 60 * 60)) / (1000 * 60));
      var seconds = Math.floor((diff % (1000 * 60)) / 1000);

      document.getElementById("cd-days").textContent = String(days).padStart(2, "0");
      document.getElementById("cd-hours").textContent = String(hours).padStart(2, "0");
      document.getElementById("cd-minutes").textContent = String(minutes).padStart(2, "0");
      document.getElementById("cd-seconds").textContent = String(seconds).padStart(2, "0");

      if (diff === 0) {
        container.querySelector(".countdown-label-main")?.classList.add("d-none");
        document.getElementById("countdown-live")?.classList.remove("d-none");
      }
    }

    update();
    setInterval(update, 1000);
  }

  window.initBbqCountdown = initCountdown;

  function initPageScroll() {
    function scrollToHash() {
      var hash = window.location.hash;
      if (!hash) return;
      var target = document.querySelector(hash);
      if (target) {
        target.scrollIntoView({ behavior: "smooth", block: "start" });
      }
    }

    scrollToHash();
    window.addEventListener("hashchange", scrollToHash);
  }

  window.initPageScroll = initPageScroll;

})();