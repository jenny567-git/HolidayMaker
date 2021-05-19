<template>
  <div class="container">
    <div class="row">
      <div class="col-md-6">
        <div class="input-group">
          <!-- <label for="exampleDataList" class="form-label">Datalist example</label> -->
          <input
            class="form-control"
            list="datalistOptions"
            id="exampleDataList"
            placeholder="Type to search..."
          />
          <datalist id="datalistOptions">
            <option value="San Francisco" />
            <option value="New York" />
            <option value="Seattle" />
            <option value="Los Angeles" />
            <option value="Chicago" />
          </datalist>

          <div class="input-group-append">
            <!-- <button class="input-group-text"><i class="fa fa-search"></i></button> -->
            <Button
              type="button"
              icon="pi pi-search"
              class="p-button-rounded p-button-success p-d-none p-d-md-inline-flex"
            />
          </div>
        </div>
      </div>
    </div>
    <div class="row">
      <p>Adults: <InputNumber v-model="value" showButtons :min="0" :max="100" value="2"/></p>
    <!-- </div>
    <div class="row"> -->
      <p>Children <InputNumber v-model="value" showButtons :min="0" :max="100" value="0"/></p>
    <!-- </div>
    <div class="row"> -->
      <p>Room <InputNumber v-model="value" showButtons :min="0" :max="100" value="1"/></p>
      
      <label for="range">Dates</label>
      <Calendar id="range" v-model="dates" selectionMode="range" :manualInput="false" :minDate="minDate"/>
    </div>
  </div>
  <!-- input field -->

  <!-- <AutoComplete v-model="selectedCity" :suggestions="filteredCities" @complete="searchCity($event)" field="label" optionGroupLabel="label" optionGroupChildren="items">
                <template #optiongroup="slotProps">
                    <div class="p-d-flex p-ai-center country-item">
                        <img src="https://www.primefaces.org/wp-content/uploads/2020/05/placeholder.png" width="18" />
                        <div class="p-ml-2">{{slotProps.item.label}}</div>
                    </div>
                </template>
            </AutoComplete> -->
</template>

<script>
import Button from "primevue/Button";
import InputNumber from 'primevue/inputnumber';
import Calendar from 'primevue/calendar';

export default {
  components: {
    Button,
    InputNumber,
    Calendar
  },
  created() {
        let today = new Date();
        let month = today.getMonth();
        let year = today.getFullYear();
        let prevMonth = (month === 0) ? 11 : month -1;
        let prevYear = (prevMonth === 11) ? year - 1 : year;
        let nextMonth = (month === 11) ? 0 : month + 1;
        let nextYear = (nextMonth === 0) ? year + 1 : year;
        this.minDate = today;
    },
  data() {
        return {
            dates: null,
            minDate: null,
        }
    }
};
</script>