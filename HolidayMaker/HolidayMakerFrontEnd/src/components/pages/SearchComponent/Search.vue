<template>
  <div class="container text-start">
    <div class="row">
      <div class="col-md-4">
        <label for="searchInput">Location </label>
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
        <input
          class="form-control"
          list="datalistOptions"
          id="searchInput"
          placeholder="Type to search..."
        />
        <datalist id="datalistOptions">
          <option value="San Francisco" />
          <option value="New York" />
          <option value="Seattle" />
          <option value="Los Angeles" />
          <option value="Chicago" />
        </datalist>
      </div>
      <div class="col-md-4">
        <div class="p-fluid p-grid p-formgrid">
          <Calendar
            id="range"
            v-model="dates"
            selectionMode="range"
            :manualInput="false"
            :minDate="minDate"
          />
        </div>
      </div>
      <div class="col-md-3">
        <div class="dropdown">
          <button
            class="btn btn-secondary dropdown-toggle"
            type="button"
            id="dropdownMenuClickableInside"
            data-bs-toggle="dropdown"
            data-bs-auto-close="outside"
            aria-expanded="false"
          >
            {{ inputAdult }} Adult(s), {{ inputChild }} Child(ren),
            {{ inputRoom }} Room(s)
          </button>
          <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
            <div class="container text-start">
              <p>
                Adult(s)
                <InputNumber
                  v-model="inputAdult"
                  showButtons
                  :min="0"
                  :max="100"
                  value="2"
                />
              </p>
              <p>
                Child(ren)
                <InputNumber
                  v-model="inputChild"
                  showButtons
                  :min="0"
                  :max="100"
                  value="0"
                />
              </p>
              <p>
                Room(s)
                <InputNumber
                  v-model="inputRoom"
                  showButtons
                  :min="0"
                  :max="100"
                  value="1"
                />
              </p>
            </div>
          </ul>
        </div>
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
import InputNumber from "primevue/inputnumber";
import Calendar from "primevue/calendar";

export default {
  components: {
    Button,
    InputNumber,
    Calendar,
  },
  created() {
    let today = new Date();
    let month = today.getMonth();
    let year = today.getFullYear();
    let prevMonth = month === 0 ? 11 : month - 1;
    let prevYear = prevMonth === 11 ? year - 1 : year;
    let nextMonth = month === 11 ? 0 : month + 1;
    let nextYear = nextMonth === 0 ? year + 1 : year;
    this.minDate = today;
  },
  data() {
    return {
      dates: null,
      minDate: null,
    };
  },
  methods: {
    onSubmit() {},
  },
  computed: {
    inputAdult: {
      get() {
        return this.$store.state.searchString.inputAdult;
      },
      set(value) {
        this.$store.dispatch("updateAdults", value);
      },
    },
    inputChild: {
      get() {
        return this.$store.state.searchString.inputChild;
      },
      set(value) {
        this.$store.dispatch("updateChild", value);
      },
    },
    inputRoom: {
      get() {
        return this.$store.state.searchString.inputRooms;
      },
      set(value) {
        this.$store.dispatch("updateRoom", value);
      },
    },
  },
};
</script>