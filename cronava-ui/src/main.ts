/**
 * main.ts
 *
 * Bootstraps Vuetify and other plugins then mounts the App`
 */

// Plugins
import {registerPlugins} from '@/plugins'

// Components
import App from './App.vue'

// Composables
import {createApp} from 'vue'
import useRouter from "@/hooks/router";
import Inbox from "@/views/Inbox.vue";
import Starred from "@/views/Starred.vue";
import Setting from './views/Setting.vue';

const router = useRouter();

router.addPage("inbox", Inbox);
router.addPage("starred", Starred);
router.addPage("settings", Setting);

router.navigateTo("inbox");

const app = createApp(App)

registerPlugins(app)

app.mount('#app')
