<template>
  <div>
    <h3>Service type:</h3>
    <div
      class="btn-group"
      role="group"
      aria-label="Basic radio toggle button group"
    >
      <input
        type="radio"
        class="btn-check"
        name="btnradio"
        id="btnradio1"
        autocomplete="off"
        checked
      />
      <label class="btn btn-outline-primary" for="btnradio1">
        Self service
      </label>

      <input
        type="radio"
        class="btn-check"
        name="btnradio"
        id="btnradio2"
        autocomplete="off"
      />
      <label class="btn btn-outline-primary" for="btnradio2">
        Half board
      </label>

      <input
        type="radio"
        class="btn-check"
        name="btnradio"
        id="btnradio3"
        autocomplete="off"
      />

      <label class="btn btn-outline-primary" for="btnradio3">
        Full board
      </label>

      <input
        type="radio"
        class="btn-check"
        name="btnradio"
        id="btnradio4"
        autocomplete="off"
      />
      <label class="btn btn-outline-primary" for="btnradio4">
        All inclusive
      </label>
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style>
</style>