## File save system (FSS)

- `~/.cronava`
  - `/meta`
    - `/accounts.db`
  - `/content`
    - `/<account_id>`
      - `/.inbox`
      - `/.trash`
      - `/.outbox`
      - `/.data`
        - `/folder1`
          - `/0.eml`
        - `/0.eml`

## IPC


```
  Client --> CLI
              |
            Service
           /       \
Service.Linux     Service.Windows
     |                   |
systemctl         Windows Service
```

## IPC Result

```
<code>;<message>
```