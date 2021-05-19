<template>
  <div class="container text-start">
    <div class="row">
      <div class="col-md-4">
        <label for="searchInput">Location/Hotel name </label>
      </div>
      <div class="col-md-4">
        <label for="range">Dates</label>
      </div>
      <div class="col-md-4">
        <label for="guest">Guests & rooms </label>
      </div>
    </div>
    <div class="row">
      <div class="col-md-4">
        <Searchfield/>
      </div>
      <div class="col-md-4">
        <div class="p-fluid p-grid p-formgrid">
          <Calendar />
        </div>
      </div>
      <div class="col-md-3">
          <SearchDropdown/>
      </div>
      <div class="col-md-1">
        <Button
          type="button"
          icon="pi pi-search"
          @click="onSubmit"
          class="p-button-rounded p-button-success p-d-none p-d-md-inline-flex"
        >
        </Button>
      </div>
    </div>
  </div>
</template>

<script>
import Button from "primevue/Button";
import Calendar from "./Datepicker.vue";
import SearchDropdown from "./SearchDropdown.vue"
import Searchfield from "./Searchfield.vue"

export default {
  components: {
    Searchfield,
    Button,
    Calendar,
    SearchDropdown
  },
  methods: {
    onSubmit() {},
  },
};
</script>