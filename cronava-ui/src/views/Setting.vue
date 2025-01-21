<template>
    <VTabs
        v-model="tab"
        align-tabs="start"
    >
        <VTab :value="1">Accounts</VTab>
        <VTab :value="2">Preferences</VTab>
        <VTab :value="3">Config Properties</VTab>
    </VTabs>
    <VTabsWindow v-model="tab">
        <VTabsWindowItem
            :key="1"
            :value="1"
        >
            <VContainer fluid>
                <h1>Accounts</h1>
            </VContainer>
        </VTabsWindowItem>
        <VTabsWindowItem
            :key="2"
            :value="2"
        >
            <VContainer fluid>
                <ThemeSettings />
                <LanguageSettings />
            </VContainer>
        </VTabsWindowItem>
        <VTabsWindowItem
            :key="3"
            :value="3"
        >
            <VContainer fluid>
                <VDataTable 
                    :items="propertyTable"
                    hover
                />
            </VContainer>
        </VTabsWindowItem>
    </VTabsWindow>
</template>

<script setup lang="ts">
import LanguageSettings from '@/components/LanguageSettings.vue';
import ThemeSettings from '@/components/ThemeSettings.vue';
import { useConfig } from '@/hooks/config';
import { ref } from 'vue';

let tab = ref<any>(null);
const config = useConfig();

const propertyTable = ref<any[]>([]);

config.forEach(item => propertyTable.value.push({key: item.key, type: item.type, value: item.value}))

</script>