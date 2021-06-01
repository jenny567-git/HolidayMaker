<template>
  <div>
    <h3>Extra bed</h3>
    <div class="p-field-checkbox">
          <Checkbox id="option" v-model="checked" :binary="true" />
          <label for="option">{{ checked }}</label>
        </div>



    <!-- with card -->

    <!-- <Card>
      <template #title>
        <h3>Extra bed</h3>
      </template>
      <template #content>
        <div class="p-field-checkbox">
          <Checkbox id="option" v-model="checked" :binary="true" />
          <label for="option">{{ checked }}</label>
        </div>
      </template>
    </Card> -->



    <!-- with bootstrap -->

    <!-- <div class="row">
      <div class="input-group mb-3">
        <div class="input-group-text">
          <input
            class="form-check-input mt-0"
            type="checkbox"
            value=""
            aria-label="Checkbox for following text input"
          />
        </div>
        <input
          type="text"
          value="Extra beds"
          class="form-control"
          aria-label="Text input with checkbox"
        />
      </div>
    </div> -->
  </div>
</template>

<script>
import Card from "primevue/card";
import Checkbox from "primevue/checkbox";

export default {
  components: {
    Checkbox,
    Card
  },
  data() {
    return {
      checked: false,
    };
  },
};
</script>

<style>
</style>