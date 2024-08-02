// Note: This is the hack for cross referencing in SwitchPlayer.
extern "C"
{
    void nnMain() __attribute__((weak));
    void SwitchVRKitRegisterPlugin() __attribute__((weak));

    void SwitchVRKitRegisterPluginEx();

    void SwitchVRKitRegisterPlugin()
    {
        SwitchVRKitRegisterPluginEx();
    }

    __attribute__((visibility("default")))
    void nnMain()
    {
        SwitchVRKitRegisterPlugin();
    }
}
