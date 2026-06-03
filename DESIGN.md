---
name: Summer BBQ Design System
colors:
  surface: '#fff8f7'
  surface-dim: '#f1d3cf'
  surface-bright: '#fff8f7'
  surface-container-lowest: '#ffffff'
  surface-container-low: '#fff0ee'
  surface-container: '#ffe9e6'
  surface-container-high: '#ffe2de'
  surface-container-highest: '#fadcd8'
  on-surface: '#271815'
  on-surface-variant: '#5b403c'
  inverse-surface: '#3e2c2a'
  inverse-on-surface: '#ffedea'
  outline: '#906f6b'
  outline-variant: '#e4beb8'
  surface-tint: '#ba1a17'
  primary: '#b61715'
  on-primary: '#ffffff'
  primary-container: '#da342b'
  on-primary-container: '#fffbff'
  inverse-primary: '#ffb4aa'
  secondary: '#006e2d'
  on-secondary: '#ffffff'
  secondary-container: '#7cf994'
  on-secondary-container: '#007230'
  tertiary: '#735c00'
  on-tertiary: '#ffffff'
  tertiary-container: '#cea700'
  on-tertiary-container: '#4e3e00'
  error: '#ba1a1a'
  on-error: '#ffffff'
  error-container: '#ffdad6'
  on-error-container: '#93000a'
  primary-fixed: '#ffdad5'
  primary-fixed-dim: '#ffb4aa'
  on-primary-fixed: '#410001'
  on-primary-fixed-variant: '#930006'
  secondary-fixed: '#7ffc97'
  secondary-fixed-dim: '#62df7d'
  on-secondary-fixed: '#002109'
  on-secondary-fixed-variant: '#005320'
  tertiary-fixed: '#ffe083'
  tertiary-fixed-dim: '#eec200'
  on-tertiary-fixed: '#231b00'
  on-tertiary-fixed-variant: '#574500'
  background: '#fff8f7'
  on-background: '#271815'
  surface-variant: '#fadcd8'
typography:
  display-lg:
    fontFamily: Bricolage Grotesque
    fontSize: 56px
    fontWeight: '800'
    lineHeight: '1.1'
    letterSpacing: -0.02em
  headline-lg:
    fontFamily: Bricolage Grotesque
    fontSize: 40px
    fontWeight: '700'
    lineHeight: '1.2'
  headline-lg-mobile:
    fontFamily: Bricolage Grotesque
    fontSize: 32px
    fontWeight: '700'
    lineHeight: '1.2'
  headline-md:
    fontFamily: Bricolage Grotesque
    fontSize: 28px
    fontWeight: '600'
    lineHeight: '1.3'
  body-lg:
    fontFamily: Be Vietnam Pro
    fontSize: 18px
    fontWeight: '400'
    lineHeight: '1.6'
  body-md:
    fontFamily: Be Vietnam Pro
    fontSize: 16px
    fontWeight: '400'
    lineHeight: '1.5'
  label-md:
    fontFamily: Be Vietnam Pro
    fontSize: 14px
    fontWeight: '600'
    lineHeight: '1.2'
    letterSpacing: 0.01em
  label-sm:
    fontFamily: Be Vietnam Pro
    fontSize: 12px
    fontWeight: '700'
    lineHeight: '1.2'
rounded:
  sm: 0.25rem
  DEFAULT: 0.5rem
  md: 0.75rem
  lg: 1rem
  xl: 1.5rem
  full: 9999px
spacing:
  base: 8px
  xs: 4px
  sm: 12px
  md: 24px
  lg: 48px
  xl: 80px
  gutter: 24px
  margin-mobile: 16px
  margin-desktop: 64px
---

## Brand & Style

This design system is built to capture the essence of an outdoor summer gathering: vibrant, energetic, and inherently social. The brand personality is "Al Fresco Joy"—it prioritizes warmth over clinical precision and community over solitude.

The visual style is a blend of **Modern-Tactile and High-Contrast**. It utilizes a "sun-drenched" aesthetic, characterized by high-saturation accents against warm, creamy neutral bases. The UI should feel inviting and "juicy," mimicking the sensory experience of a summer feast. We avoid sharp edges and cold grays in favor of organic shapes and a palette that feels edible and organic.

## Colors

The palette is derived from the textures of a backyard cookout. 
- **Primary (Tomato Red):** Used for primary actions, critical highlights, and brand-heavy elements. It communicates heat, energy, and appetite.
- **Secondary (Grass Green):** Represents the outdoor setting. Used for secondary actions, success states, and balancing the intensity of the red.
- **Tertiary (Sunny Yellow):** Used for accents, warnings (softened), and "golden hour" highlights.
- **Neutrals:** We move away from pure white and black. The background is a warm corn-silk cream, and the text is a deep, smoky mahogany charcoal to maintain a soft but high-contrast readability.

## Typography

The typography strategy balances playful character with high legibility.

**Bricolage Grotesque** is our display face. Its quirky, slightly eccentric terminals add a sense of movement and "fun" to the headlines. It should be used for all large-scale type to establish the energetic tone of the design system.

**Be Vietnam Pro** serves as the functional workhorse. It is contemporary and friendly, with a generous x-height that ensures readability even during fast-paced interactions. It maintains the approachable brand voice while providing the necessary structure for lists, descriptions, and labels.

## Layout & Spacing

This design system employs a **Fluid Grid** model based on an 8px rhythmic scale. 

- **Desktop:** A 12-column grid with 24px gutters and large 64px outer margins to allow the content to "breathe" like an open park.
- **Mobile:** A 4-column grid with 16px margins.
- **Spacing Philosophy:** Use generous white space (the "lg" and "xl" units) between major sections to prevent the vibrant colors from feeling overwhelming. Elements should feel grouped but never crowded.

## Elevation & Depth

We avoid the clinical look of standard drop shadows. Instead, the design system uses **Tonal Layers and Tinted Ambient Shadows**.

Depth is created through:
1.  **Color Stacking:** Surfaces that sit closer to the user are slightly lighter than the warm cream background.
2.  **Soft Shadows:** When an element requires lift (like a floating action button or a modal), use a shadow tinted with the primary Tomato Red at a very low opacity (5-8%). This creates a "glow" rather than a dark void.
3.  **Physicality:** Elements should feel like they are resting on a surface. Use 1px internal strokes (inner shadows or subtle borders) in a slightly darker tan to give cards a tangible, paper-like edge.

## Shapes

The shape language is **Rounded (Level 2)**. 

Standard components utilize a 0.5rem (8px) radius. Larger containers, such as hero sections or cards, should use `rounded-xl` (1.5rem / 24px). This softness mimics the organic nature of food and outdoor environments, removing any perceived digital "coldness." Avoid sharp corners entirely to maintain the casual and inviting vibe.

## Components

### Buttons
Primary buttons are high-energy Tomato Red with bold white text. They should have a subtle "bounce" on hover. Secondary buttons use the Grass Green or a ghost-style outline in the smoky charcoal text color. Use `rounded-xl` for a friendlier, more pill-like appearance on buttons.

### Cards
Cards are the primary container for content. Use a white background (contrasting against the cream page background) with a 1px soft tan border. Corner radius should be 24px.

### Chips & Tags
Use the Grass Green and Sunny Yellow for chips. These should be fully pill-shaped (rounded-full) and used to categorize items like "Spicy," "Vegetarian," or "Event Type."

### Inputs
Text fields should have a thick 2px border in a soft tan, turning Tomato Red on focus. Use the `body-md` typography for placeholder text.

### Interactive Elements
Checkboxes and Radios should be slightly oversized to feel more "clunky" and fun rather than tiny and precise. When active, they should fill with the Primary color and use a thick white checkmark.