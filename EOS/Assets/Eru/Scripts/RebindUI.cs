using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class RebindUI : MonoBehaviour
{
    // ���o�C���h�Ώۂ�Action
    [SerializeField] private InputActionReference _actionRef;

    // ���o�C���h�Ώۂ�Scheme
    [SerializeField] private string _scheme = "Keyboard";

    // ���݂�Binding�̃p�X��\������e�L�X�g
    [SerializeField] private TMP_Text _pathText;

    // ���o�C���h���̃}�X�N�p�I�u�W�F�N�g
    [SerializeField] private GameObject _mask;

    private InputAction _action;
    private InputActionRebindingExtensions.RebindingOperation _rebindOperation;

    // ������
    private void Awake()
    {
        if (_actionRef == null) return;

        // InputAction�C���X�^���X��ێ����Ă���
        _action = _actionRef.action;

        // �L�[�o�C���h�̕\���𔽉f����
        RefreshDisplay();
    }

    // �㏈��
    private void OnDestroy()
    {
        // �I�y���[�V�����͕K���j������K�v������
        CleanUpOperation();
    }

    // ���o�C���h���J�n����
    public void StartRebinding()
    {
        // ����Action���ݒ肳��Ă��Ȃ���΁A�������Ȃ�
        if (_action == null) return;

        // ���o�C���h�Ώۂ�BindingIndex���擾
        var bindingIndex = _action.GetBindingIndex(
            InputBinding.MaskByGroup(_scheme)
        );

        // ���o�C���h���J�n����
        OnStartRebinding(bindingIndex);
    }

    // �㏑�����ꂽ�������Z�b�g����
    public void ResetOverrides()
    {
        // Binding�̏㏑����S�ĉ�������
        _action?.RemoveAllBindingOverrides();
        RefreshDisplay();
    }

    // ���݂̃L�[�o�C���h�\�����X�V
    public void RefreshDisplay()
    {
        if (_action == null || _pathText == null) return;

        _pathText.text = _action.GetBindingDisplayString();
    }

    // �w�肳�ꂽ�C���f�b�N�X��Binding�̃��o�C���h���J�n����
    private void OnStartRebinding(int bindingIndex)
    {
        // �������o�C���h���Ȃ�A�����I�ɃL�����Z��
        // Cancel���\�b�h�����s����ƁAOnCancel�C�x���g�����΂���
        _rebindOperation?.Cancel();

        // ���o�C���h�O��Action�𖳌�������K�v������
        _action.Disable();

        // �u���b�L���O�p�}�X�N��\��
        if (_mask != null)
            _mask.SetActive(true);

        // ���o�C���h���I���������̏������s�����[�J���֐�
        void OnFinished(bool hideMask = true)
        {
            // �I�y���[�V�����̌㏈��
            CleanUpOperation();

            // �ꎞ�I�ɖ���������Action��L��������
            _action.Enable();

            // �u���b�L���O�p�}�X�N���\��
            if (_mask != null && hideMask)
                _mask.SetActive(false);
        }

        // ���o�C���h�̃I�y���[�V�������쐬���A
        // �e��R�[���o�b�N�̐ݒ�����{���A
        // �J�n����
        _rebindOperation = _action
            .PerformInteractiveRebinding(bindingIndex)
            .OnComplete(_ =>
            {
                // ���o�C���h�������������̏���
                RefreshDisplay();

                var bindings = _action.bindings;
                var nextBindingIndex = bindingIndex + 1;

                if (nextBindingIndex <= bindings.Count - 1 && bindings[nextBindingIndex].isPartOfComposite)
                {
                    // Composite Binding�̈ꕔ�Ȃ�A����Binding�̃��o�C���h���J�n����
                    OnFinished(false);
                    OnStartRebinding(nextBindingIndex);
                }
                else
                {
                    OnFinished();
                }
            })
            .OnCancel(_ =>
            {
                // ���o�C���h���L�����Z�����ꂽ���̏���
                OnFinished();
            })
            .OnMatchWaitForAnother(0.2f) // ���̃��o�C���h�܂ł̑ҋ@���Ԃ�݂���
            .Start(); // �����Ń��o�C���h���J�n����
    }

    // ���o�C���h�I�y���[�V������j������
    private void CleanUpOperation()
    {
        // �I�y���[�V�������쐬������ADispose���Ȃ��ƃ��������[�N����
        _rebindOperation?.Dispose();
        _rebindOperation = null;
    }
}