<template>
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
</template>

<script>
import InputNumber from "primevue/inputnumber";

export default {
components: {
    InputNumber,
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
}
}

</script>

<style>

</style>