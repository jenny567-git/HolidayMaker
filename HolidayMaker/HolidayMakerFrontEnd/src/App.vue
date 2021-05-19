<template>
  <main>
    <div class="container">
      <div>
        <Menu ref="menu" :model="items" :popup="true" />
        <Button type="button" label="Toggle" @click="toggle" />
        <h5>Inline</h5>
        <InputText class="p-mr-2 p-d-inline" />
        <InputText class="p-d-inline" />

        <h5>Block</h5>
        <InputText class="p-mb-2 p-d-block" />
        <InputText class="p-d-block" />

        <h5>Visible on a Small Screen</h5>
        <p>Resize to view.</p>
        <Button type="button" icon="pi pi-search" class="p-button-rounded p-button-success p-d-none p-d-md-inline-flex " >  </Button>

        <h5>Hidden on a Small Screen</h5>
        <p>Resize to hide.</p>
        <Button type="button" icon="pi pi-search" class="p-button-rounded p-button-success p-d-none p-d-md-inline-flex" />

        <h5>Visible to Print, Invisible for Screen</h5>
        <p class="p-d-none p-d-print-block">Only visible when printed.</p>

        <h5>Visible to Screen, Invisible for Print</h5>
        <p class="p-d-block p-d-print-none">Not available for printing.</p>
    </div>
      <ColorPicker v-model="color2" />
      <Dialog></Dialog>
      <img alt="Vue logo" src="./assets/logo.png" />
      <Searcher/>
      <router-view/>
    </div>
  </main>
</template>

<script>
import ConfirmDate from './components/pages/Datepicker/ConfirmDate.vue'
import Dialog from 'primevue/dialog';
import InputText from 'primevue/InputText';
import Button from 'primevue/Button';
import Menu from 'primevue/menu';
import ColorPicker from 'primevue/colorpicker';
import Searcher from './components/pages/SearchComponent/Search.vue'

export default {
  name: 'App',
  components: {
    ConfirmDate,
    Dialog,
    ColorPicker,
    InputText,
    Button,
    Menu,
    Searcher
  },
  data() {
        return {
            color2: '1976D2',
            items: [
            {
              label: 'Update',
              icon: 'pi pi-refresh',
              command: () => {
                this.$toast.add({severity:'success', summary:'Updated', detail:'Data Updated', life: 3000});
              }
            },
            {
              label: 'Delete',
              icon: 'pi pi-times',
              command: () => {
                this.$toast.add({ severity: 'warn', summary: 'Delete', detail: 'Data Deleted', life: 3000});
              }
            },
            {
              label: 'Vue Website',
              icon: 'pi pi-external-link',
              url: 'https://vuejs.org/'
            },
            {
              label: 'Router',
              icon: 'pi pi-upload',
              to: '/fileupload'
            }
			    ]
        }
    },
    methods:{
      toggle(event) {
        this.$refs.menu.toggle(event);
      }
    }
}


</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

.input-group{
    margin-left: auto;
    margin-right: auto;
    display: flex;
    width: fit-content;
    align-content: center;
}


</style>
