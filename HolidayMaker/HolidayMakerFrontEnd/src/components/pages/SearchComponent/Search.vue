<template>
  <div class="container text-start">
    <div class="row">
      <div class="col-md-4">
        <label for="searchInput">Location/Hotel name </label>
        <Searchfield />
      </div>
      <div class="col-md-4">
        <div class="p-fluid p-grid p-formgrid">
          <label for="range">Dates</label>
          <Calendar />
        </div>
      </div>
      <div class="col-md-3">
        <label for="guest">Guests & rooms </label>
        <SearchDropdown />
      </div>
      <div class="col-md-1">
        <div class="p-grid">
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
  </div>
</template>

<script>
import Button from "primevue/Button";
import Calendar from "./Datepicker.vue";
import SearchDropdown from "./SearchDropdown.vue";
import Searchfield from "./Searchfield.vue";

export default {
  components: {
    Searchfield,
    Button,
    Calendar,
    SearchDropdown,
  },
  methods: {
    onSubmit() {},
  },
};
</script>

<style scoped>
.container {
  background-color: #97a97c;
  color: #283618;
  border-radius: 25px;
  padding-left: 50px;
  padding-right: 50px;
  padding-top: 30px;
  padding-bottom: 30px;
}
</style>