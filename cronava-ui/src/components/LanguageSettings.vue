<template>
    <h1 class="pb-3">Language</h1>
    <VSelect
        label="Language"
        :items="LANGUAGES"
        item-title="text"
        item-value="value"
        v-model="activeLanguage"
        variant="solo"
        @update:model-value="config.theme.value = activeLanguage.value"
    />
</template>

<script setup lang="ts">
import { useConfig } from '@/hooks/config';
import { ref } from 'vue';
import { useTheme } from 'vuetify';

const LANGUAGES = [
    {
        text: "English", value: "english"
    },
    {
        text: "German", value: "german"
    }
];

const config = useConfig();
const theme = useTheme();

const activeLanguage = ref(LANGUAGES.find(o => o.value == config.language.value)!);

</script>