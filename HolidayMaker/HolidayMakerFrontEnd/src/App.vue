<template>
  <main>
    <Navigator/>
      <div style="background: url(https://i.postimg.cc/ZnHTP71s/aircraft-airplane-boat-1575833.jpg);" class="page-holder bg-cover">
        <div class="container">
          <div>
            <h5>Search - temp</h5>
            <InputText v-model="searchString" class="p-mr-2 p-d-inline" />
            <Button class="p-mx-auto" label="Search" @click="Search" :loading="isLoading"/>
         </div>
          <router-view/>
        </div>
    </div>
    <Footer/>
  </main>
</template>

<script>
import ConfirmDate from './components/pages/Datepicker/ConfirmDate.vue'
import Dialog from 'primevue/dialog';
import InputText from 'primevue/InputText';
import Button from 'primevue/Button';
import Menu from 'primevue/menu';
import ColorPicker from 'primevue/colorpicker';
import Navigator from '/src/components/Navigator.vue';
import Footer from '/src/components/Footer.vue';
import Body from "/src/components/pages/MainPage/Body.vue";
export default {
  name: "App",
  components: {
    ConfirmDate,
    Dialog,
    ColorPicker,
    InputText,
    Button,
    Menu,
    Navigator,
    Footer,
    Body
  },
  data() {
        return {
          searchString: '',
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
      },
      Search(event){
        this.$store.state.searchButtonLoading = true;

        this.$store.dispatch('searchHotels', this.searchString);
      }
    },
    computed:{
      isLoading(){
        return this.$store.state.searchButtonLoading;
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

.input-group {
  margin-left: auto;
  margin-right: auto;
  display: flex;
  width: fit-content;
  align-content: center;
}
</style>
