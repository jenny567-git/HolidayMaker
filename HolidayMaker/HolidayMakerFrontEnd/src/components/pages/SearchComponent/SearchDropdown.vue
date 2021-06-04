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
            <b>{{ inputAdult }} <i class="fas fa-user"></i></b>
            <b>{{ inputChild }} <i class="fas fa-baby"></i></b>
            <b>{{ inputRoom }} <i class="fas fa-bed"></i></b>
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
                  value="0"
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
                  value="0"
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

<style scoped>
.dropdown-toggle{
  background-color: #43744f;
}
b{
  padding-left: 10px;
}
</style>