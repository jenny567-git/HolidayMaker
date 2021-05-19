<template>
  <Calendar
    dateFormat="yy-mm-dd"
    v-model="dates"
    selectionMode="range"
    :manualInput="false"
    :minDate="minDate"
  />
</template>

<script>
import Button from "primevue/Button";
import Calendar from "primevue/calendar";

export default {
  components: {
    Calendar,
    Button
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
};
</script>

<style>
</style>