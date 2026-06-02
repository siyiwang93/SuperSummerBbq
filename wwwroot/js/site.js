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

  function initLandingPanels() {
    var panels = document.querySelectorAll(".landing-panel");
    var navLinks = document.querySelectorAll(".landing-nav-link");
    if (!panels.length) return;

    function showPanel(name) {
      panels.forEach(function (panel) {
        var isActive = panel.getAttribute("data-landing-panel") === name;
        panel.classList.toggle("d-none", !isActive);
      });

      navLinks.forEach(function (link) {
        var active = link.getAttribute("data-landing-panel") === name;
        link.classList.toggle("active", active);
        link.setAttribute("aria-current", active ? "page" : "false");
      });
    }

    function panelFromHash() {
      var hash = (window.location.hash || "").replace("#", "").toLowerCase();
      if (hash === "agenda" || hash === "faq") return hash;
      return "home";
    }

    navLinks.forEach(function (link) {
      link.addEventListener("click", function (e) {
        var panel = link.getAttribute("data-landing-panel");
        if (!panel || panel === "home") return;

        var onLandingPage = document.getElementById("panel-agenda");
        if (!onLandingPage) return;

        e.preventDefault();
        history.replaceState(null, "", "#" + panel);
        showPanel(panel);
        var target = document.getElementById("panel-" + panel);
        if (target) target.scrollIntoView({ behavior: "smooth", block: "start" });
      });
    });

    showPanel(panelFromHash());
    window.addEventListener("hashchange", function () {
      showPanel(panelFromHash());
    });
  }

  window.initLandingPanels = initLandingPanels;
})();