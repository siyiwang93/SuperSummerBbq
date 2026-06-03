# Super Summer BBQ 2026 — Design System

> **Borrowed from:** [VoltAgent/awesome-design-md](https://github.com/VoltAgent/awesome-design-md) — `design-md/airbnb/DESIGN.md` (warm, welcoming marketplace patterns).  
> **Adapted for:** internal event registration portal — retro summer cookout (terracotta / gold / sage on cream), not consumer marketplace.

---

```yaml
---
version: 1.0
name: SuperSummerBbq-design
description: >
  A warm, generous internal event portal on a cream canvas with terracotta (#c44d2a) as the
  primary CTA voltage and gold (#f0b429) as accent highlights. Display type uses Fraunces;
  body uses Atkinson Hyperlegible. The hero carries hierarchy (gradient + countdown); cards
  and forms stay friendly with soft radii and generous section spacing. Nav is dark ink with
  gold underline; in-page anchors (Agenda, FAQ) use smooth scroll.

colors:
  primary: "#c44d2a"
  primary-active: "#9a3a20"
  primary-disabled: "#e8c4b8"
  accent: "#f0b429"
  accent-soft: "#ffe8a3"
  ink: "#1a1410"
  body: "#2f2924"
  muted: "#5c534c"
  hairline: "#e0d5c8"
  canvas: "#faf6ef"
  canvas-deep: "#f3ebe0"
  surface-card: "#ffffff"
  surface-soft: "#e8f2eb"
  sage: "#3d6b4f"
  sky: "#4a8fad"
  on-primary: "#fff8f0"
  on-dark: "#fff8f0"
  shadow: "rgba(26, 20, 16, 0.12)"

typography:
  display-xl:
    fontFamily: "'Fraunces', Georgia, serif"
    fontSize: 48px
    fontWeight: 800
    lineHeight: 1.1
    letterSpacing: 0.02em
  display-lg:
    fontFamily: "'Fraunces', Georgia, serif"
    fontSize: 32px
    fontWeight: 600
    lineHeight: 1.2
  display-md:
    fontFamily: "'Fraunces', Georgia, serif"
    fontSize: 24px
    fontWeight: 600
    lineHeight: 1.25
  title-md:
    fontFamily: "'Atkinson Hyperlegible', system-ui, sans-serif"
    fontSize: 18px
    fontWeight: 700
    lineHeight: 1.3
  body-md:
    fontFamily: "'Atkinson Hyperlegible', system-ui, sans-serif"
    fontSize: 16px
    fontWeight: 400
    lineHeight: 1.5
  body-sm:
    fontFamily: "'Atkinson Hyperlegible', system-ui, sans-serif"
    fontSize: 14px
    fontWeight: 400
    lineHeight: 1.45
  caption:
    fontFamily: "'Atkinson Hyperlegible', system-ui, sans-serif"
    fontSize: 12px
    fontWeight: 700
    lineHeight: 1.33
    letterSpacing: 0.08em
    textTransform: uppercase
  button-md:
    fontFamily: "'Atkinson Hyperlegible', system-ui, sans-serif"
    fontSize: 16px
    fontWeight: 700
    lineHeight: 1.25
  nav-link:
    fontFamily: "'Atkinson Hyperlegible', system-ui, sans-serif"
    fontSize: 13px
    fontWeight: 700
    lineHeight: 1.25
    letterSpacing: 0.03em
    textTransform: uppercase

rounded:
  sm: 8px
  md: 14px
  lg: 20px
  xl: 32px
  full: 9999px

spacing:
  xs: 4px
  sm: 8px
  md: 16px
  lg: 24px
  xl: 32px
  section: 64px

components:
  button-primary:
    backgroundColor: "{colors.primary}"
    textColor: "{colors.on-primary}"
    typography: "{typography.button-md}"
    rounded: "{rounded.md}"
    padding: 14px 28px
  button-secondary:
    backgroundColor: transparent
    textColor: "{colors.on-dark}"
    border: "2px solid rgba(255, 248, 240, 0.5)"
    rounded: "{rounded.md}"
  top-nav:
    backgroundColor: "rgba(26, 20, 16, 0.92)"
    textColor: "{colors.on-dark}"
    borderBottom: "3px solid {colors.accent}"
    height: 56px
  hero-band:
    background: "linear-gradient(145deg, #1a1410 0%, #3d2618 35%, #8b3d22 70%, #c44d2a 100%)"
    textColor: "{colors.on-dark}"
  event-card:
    backgroundColor: "{colors.surface-card}"
    rounded: "{rounded.lg}"
    padding: "{spacing.lg}"
    shadow: "{colors.shadow}"
  form-input:
    backgroundColor: "{colors.surface-card}"
    border: "1px solid {colors.hairline}"
    rounded: "{rounded.sm}"
    height: 48px
  countdown-digit:
    typography: "{typography.display-lg}"
    color: "{colors.accent}"
```

## CSS variables (implementation)

Map tokens in `wwwroot/css/site.css`:

| Token | Variable |
|-------|----------|
| Primary | `--bbq-terracotta` |
| Primary active | `--bbq-terracotta-dark` |
| Accent | `--bbq-gold` |
| Ink / body | `--bbq-ink`, `--bbq-charcoal` |
| Canvas | `--bbq-cream`, `--bbq-cream-deep` |
| Sage accent | `--bbq-sage`, `--bbq-sage-light` |
| Display font | `--font-display` (Fraunces) |
| Body font | `--font-body` (Atkinson Hyperlegible) |

## Brand principles (from Airbnb, applied to BBQ)

1. **One hot color** — Terracotta owns primary CTAs (Register Now, Submit). Gold is accent only (nav underline, countdown, badges).
2. **Photography / atmosphere over type muscle** — Hero gradient and texture do hierarchy; headlines are confident but not enterprise-heavy.
3. **Friendly geometry** — Cards use `{rounded.lg}`; buttons `{rounded.md}`; no sharp corporate corners on marketing surfaces.
4. **Generous whitespace** — Section bands use `{spacing.section}` (64px); card grids can be denser (16px gutters) for agenda rows.
5. **Trust through clarity** — Registration count, event date/location, and FAQ visible without hunting.

## Page map

| Surface | Role |
|---------|------|
| Landing (`Home/Index`) | Hero, countdown, live registration count, Agenda `#agenda`, FAQ `#faq` |
| Register / Manage | Forms with `{component.form-input}`; lookup by Employee ID + email |
| Admin | Stats dashboard; utilitarian tables (can relax marketing polish) |

## Components (BBQ-specific)

### Navigation (`bbq-navbar`)

Dark bar, gold bottom border, uppercase nav links. Links: Home, Agenda (scroll), FAQ (scroll), My Registration, Register Now (primary). No duplicate Register in hero button row next to Register Now — My Registration lives in nav only.

### Hero (`bbq-hero`)

Full-width gradient band, event title, date/location, single **Register Now** CTA. Countdown digits in gold; no separate “Countdown to the BBQ” heading.

### Event cards

Agenda and FAQ sections: full-width stacked rows (not side-by-side on desktop). White cards on cream with soft shadow; section titles in Fraunces.

### Forms

Bootstrap 5 base + BBQ overrides. Labels `{typography.caption}`; inputs `{component.form-input}`. Primary submit uses terracotta fill.

### Buttons

- **Primary** — Terracotta, cream text, hover `{colors.primary-active}`.
- **Secondary** — Outline on hero (cream border); on cream pages, outline charcoal or sage as needed.

## Responsive behavior

| Breakpoint | Changes |
|------------|---------|
| Mobile | Nav collapses to toggler; hero padding reduced; agenda/FAQ single column |
| Tablet+ | Full nav; hero two-column meta where applicable |
| Desktop | Max content ~1140px (Bootstrap container); smooth scroll offset `5.5rem` for fixed nav |

Touch targets: minimum 44×44px on nav and primary CTAs.

## Accessibility

- Body font chosen for legibility (Atkinson Hyperlegible).
- Contrast: cream body text on charcoal meets WCAG for long copy; hero uses cream on dark gradient.
- Focus visible on links and form controls.
- `scroll-behavior: smooth` with `scroll-padding-top` / `scroll-margin-top` for anchor targets.

## Known gaps

- Admin dashboard uses default Bootstrap tables — not fully tokenized.
- No dark mode.
- Email confirmation is simulated (on-screen + server log only).

## Source reference

Full Airbnb analysis (colors, search pill, listing cards, etc.) lives in awesome-design-md:

`https://github.com/VoltAgent/awesome-design-md/blob/main/design-md/airbnb/DESIGN.md`

Use that file when building net-new marketing patterns; this document is the **project-specific** override layer.