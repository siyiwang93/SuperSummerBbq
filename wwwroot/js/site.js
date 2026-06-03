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

  function isHomePage() {
    var path = window.location.pathname.toLowerCase().replace(/\/+$/, "") || "/";
    return path === "" || path === "/" || path.endsWith("/home") || path.endsWith("/home/index");
  }

  function initNavHighlight() {
    var nav = document.querySelector(".bbq-navbar");
    if (!nav) return;

    var homeLink = nav.querySelector('[data-nav="home"]');
    var agendaLink = nav.querySelector('[data-nav="agenda"]');
    var faqLink = nav.querySelector('[data-nav="faq"]');
    var sectionLinks = [homeLink, agendaLink, faqLink].filter(Boolean);

    function update() {
      sectionLinks.forEach(function (link) {
        link.classList.remove("active");
      });

      if (!isHomePage()) return;

      var hash = window.location.hash;
      if (hash === "#agenda" && agendaLink) {
        agendaLink.classList.add("active");
      } else if (hash === "#faq" && faqLink) {
        faqLink.classList.add("active");
      } else if (homeLink) {
        homeLink.classList.add("active");
      }
    }

    update();
    window.addEventListener("hashchange", update);
  }

  window.initNavHighlight = initNavHighlight;

  document.addEventListener("DOMContentLoaded", initNavHighlight);
})();