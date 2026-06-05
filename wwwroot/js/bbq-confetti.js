(function () {
  var COLORS = ["#b61715", "#da342b", "#006e2d", "#7cf994", "#735c00", "#ffe083", "#ffb4aa", "#ffdad5"];

  function resizeCanvas(canvas) {
    canvas.width = window.innerWidth;
    canvas.height = window.innerHeight;
  }

  function createParticles(canvas, count, originX, originY) {
    var particles = [];
    for (var i = 0; i < count; i++) {
      var angle = Math.random() * Math.PI * 2;
      var speed = 4 + Math.random() * 10;
      particles.push({
        x: originX,
        y: originY,
        w: 5 + Math.random() * 7,
        h: 8 + Math.random() * 10,
        color: COLORS[Math.floor(Math.random() * COLORS.length)],
        rotation: Math.random() * Math.PI,
        rotationSpeed: (Math.random() - 0.5) * 0.25,
        vx: Math.cos(angle) * speed,
        vy: Math.sin(angle) * speed - 6,
        gravity: 0.12 + Math.random() * 0.12,
        opacity: 1
      });
    }
    return particles;
  }

  function launchBbqConfetti(durationMs) {
    if (window.matchMedia("(prefers-reduced-motion: reduce)").matches) {
      return;
    }

    var canvas = document.getElementById("bbq-confetti-canvas");
    if (!canvas) {
      return;
    }

    var ctx = canvas.getContext("2d");
    if (!ctx) {
      return;
    }

    resizeCanvas(canvas);

    var centerX = canvas.width * 0.5;
    var centerY = canvas.height * 0.32;
    var particles = createParticles(canvas, 140, centerX, centerY);
    particles = particles.concat(createParticles(canvas, 60, centerX * 0.3, centerY));
    particles = particles.concat(createParticles(canvas, 60, centerX * 1.7, centerY));

    var start = performance.now();
    var end = start + (durationMs || 4000);

    function frame(now) {
      ctx.clearRect(0, 0, canvas.width, canvas.height);

      particles.forEach(function (p) {
        p.vy += p.gravity;
        p.x += p.vx;
        p.y += p.vy;
        p.vx *= 0.99;
        p.rotation += p.rotationSpeed;

        if (now > end - 1000) {
          p.opacity = Math.max(0, p.opacity - 0.018);
        }

        ctx.save();
        ctx.globalAlpha = p.opacity;
        ctx.translate(p.x, p.y);
        ctx.rotate(p.rotation);
        ctx.fillStyle = p.color;
        ctx.fillRect(-p.w * 0.5, -p.h * 0.5, p.w, p.h);
        ctx.restore();
      });

      if (now < end) {
        requestAnimationFrame(frame);
      } else {
        ctx.clearRect(0, 0, canvas.width, canvas.height);
      }
    }

    requestAnimationFrame(frame);

    window.addEventListener("resize", function () {
      resizeCanvas(canvas);
    });
  }

  window.launchBbqConfetti = launchBbqConfetti;
})();