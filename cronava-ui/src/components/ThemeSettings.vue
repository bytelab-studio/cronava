<template>
    <h1 class="pb-3">Theme</h1>
    <VSelect 
        label="Theme"
        :items="THEMES"
        item-title="text"
        item-value="value"
        v-model="activeTheme"
        variant="solo"
        v-on:change="config.theme.value = activeTheme.value"
    />
    <VSwitch
        v-model="darkMode"
        color="primary"
        label="DarkMode"
        @update:model-value="toggleTheme"
    />
</template>

<script setup lang="ts">
import { useConfig } from '@/hooks/config';
import { ref } from 'vue';
import { useTheme } from 'vuetify';

const THEMES = [
    {
        text: "Material Flat", value: "material-flat"
    },
    {
        text: "Material Simple", value: "material-simple"
    }
];

const config = useConfig();
const theme = useTheme();

const darkMode = ref(config.darkMode.value);
const activeTheme = ref(THEMES.find(o => o.value == config.theme.value)!);

function toggleTheme() {
    config.darkMode.value = darkMode.value;
    theme.global.name.value = darkMode.value ? "dark" : "light";
}

</script>