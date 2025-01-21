import {ref} from "vue";

type NT2T<NT> = NT extends "boolean" ? boolean : NT extends "string" ? string : NT extends "number" ? number : never;
type NTs = "boolean" | "string" | "number";

class ConfigItem<NT extends NTs, T = NT2T<NT>> {
  private static keys: string[] = [];

  private _value;
  private readonly watchers: Array<(o: T, n: T) => void>;
  public readonly key: string;
  public readonly type: NT;
  
  public constructor(key: string[], type: NT, defaultValue: T) {
    this.key = key.join(".");
    this.type = type;
    this.watchers = [];
    this._value = ref<T>(defaultValue);
    if (!this.load()) {
      this.store();
    }

    if (ConfigItem.keys.includes(this.key)) {
      throw `A config item with the key '${this.key}' was already declared`;
    }
    ConfigItem.keys.push(this.key);
  }

  public get value(): T {
    return this._value.value;
  }

  public set value(value: T) {
    debugger;
    const o = this._value.value;
    this._value.value = value;
    this.store();
    this.watchers.forEach(cb => cb(o, this._value.value));
  }

  public watch(cb: (o: T, n: T) => void): void {
    this.watchers.push(cb);
  }

  private load(): boolean {
    const item = localStorage.getItem(this.key);
    if (!item) {
      return false;
    }
    switch (this.type) {
      case "boolean":
        this._value.value = item == "true";
        break;
      case "string":
        this._value.value = item;
        break;
      case "number":
        this._value.value = parseFloat(item);
        break;
    }
    return true;
  }

  private store() {
    localStorage.setItem(this.key, this._value.value.toString());
  }
}

const config = {
  darkMode: new ConfigItem(["ui", "theme", "darkmode"], "boolean", false),
  theme: new ConfigItem(["ui", "theme", "theme"], "string", "material-flat"),
  language: new ConfigItem(["ui", "language"], "string", "english"),
  dateFormat: new ConfigItem(["format", "date"], "string", "DD.MM.YYYY"),
  timeFormat: new ConfigItem(["format", "time"], "string", "HH:mm"),
  sidebarCollapsed: new ConfigItem(["layout", "sidebar", "collapsed"], "boolean", false),
  openGlobalSearch: new ConfigItem(["hotkeys", "globalSearch", "open"], "string", "shift+alt+s")
}

export function useConfig() {
  return {
    ...config,
    forEach(cb: (item: ConfigItem<any, any>) => void) {
      for (const value of Object.values(config)) {
        cb(value);
      }
    }
  };
}
